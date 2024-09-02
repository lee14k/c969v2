using c969v2.Models;
using System.Collections.Generic;
using System;
using System.Linq;

public class Appointment
{
    public int AppointmentId { get; set; }
    public int CustomerId { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Contact { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public string LastUpdateBy { get; set; }

    // Navigation properties to link to Customer and User
    public Customer Customer { get; set; }
    public User User { get; set; }

    // Static list to store appointment records
    private static List<Appointment> appointments = new List<Appointment>();

    // Method to add a new appointment
    public static void AddAppointment(Appointment appointment)
    {
        ValidateAppointment(appointment);
        appointments.Add(appointment);
    }

    // Method to update an existing appointment
    public static void UpdateAppointment(int index, Appointment appointment)
    {
        ValidateAppointment(appointment);
        appointments[index] = appointment;
    }

    // Method to delete an appointment
    public static void DeleteAppointment(int index)
    {
        appointments.RemoveAt(index);
    }

    // Method to validate appointment data
    private static void ValidateAppointment(Appointment appointment)
    {
        if (!appointment.IsWithinBusinessHours())
        {
            throw new ArgumentException("Appointment must be within business hours (9:00 a.m. to 5:00 p.m., Monday–Friday, EST).");
        }

        if (appointment.IsOverlapping(appointments))
        {
            throw new ArgumentException("Appointment times overlap with an existing appointment.");
        }
    }

    // Method to check if the appointment is within business hours
    public bool IsWithinBusinessHours()
    {
        // Convert the appointment start time to Eastern Standard Time (EST)
        TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        DateTime appointmentStartEST = TimeZoneInfo.ConvertTimeFromUtc(this.Start.ToUniversalTime(), easternZone);
        DateTime appointmentEndEST = TimeZoneInfo.ConvertTimeFromUtc(this.End.ToUniversalTime(), easternZone);

        // Check if the appointment is within business hours (9:00 a.m. to 5:00 p.m.) and on a weekday
        bool withinBusinessHours = appointmentStartEST.TimeOfDay >= TimeSpan.FromHours(9) &&
                                   appointmentEndEST.TimeOfDay <= TimeSpan.FromHours(17) &&
                                   appointmentStartEST.DayOfWeek != DayOfWeek.Saturday &&
                                   appointmentStartEST.DayOfWeek != DayOfWeek.Sunday;

        return withinBusinessHours;
    }

    // Method to check if the appointment overlaps with existing appointments
    public bool IsOverlapping(List<Appointment> existingAppointments)
    {
        foreach (var appointment in existingAppointments)
        {
            if (this.UserId == appointment.UserId &&
                this.AppointmentId != appointment.AppointmentId && // Exclude the current appointment if updating
                this.Start < appointment.End && this.End > appointment.Start)
            {
                return true; // Overlapping
            }
        }
        return false;
    }

    // Method to get all appointments
    public static List<Appointment> GetAllAppointments()
    {
        return appointments;
    }
}