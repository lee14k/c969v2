using System;

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

    public void ValidateFields()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new Exception("Please fill out the Title.");

        if (Title.Length > 255)
            throw new Exception("Title cannot exceed 255 characters.");

        if (string.IsNullOrWhiteSpace(Location))
            throw new Exception("Please fill out the Location.");

        if (Location.Length > 255)
            throw new Exception("Location cannot exceed 255 characters.");

        if (string.IsNullOrWhiteSpace(Contact))
            throw new Exception("Please fill out the Contact.");

        if (Contact.Length > 255)
            throw new Exception("Contact cannot exceed 255 characters.");

        if (string.IsNullOrWhiteSpace(Type))
            throw new Exception("Please fill out the Type.");

        if (Type.Length > 255)
            throw new Exception("Type cannot exceed 255 characters.");

        if (!string.IsNullOrWhiteSpace(Url) && Url.Length > 255)
            throw new Exception("URL cannot exceed 255 characters.");
    }
}

