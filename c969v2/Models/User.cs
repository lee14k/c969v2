using System.Collections.Generic;
using System;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool Active { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public string LastUpdateBy { get; set; }

    // Static list to store user records
    private static List<User> users = new List<User>();

    // Method to add a new user
    public static void AddUser(User user)
    {
        users.Add(user);
    }

    // Method to update an existing user
    public static void UpdateUser(int index, User user)
    {
        users[index] = user;
    }

    // Method to delete a user
    public static void DeleteUser(int index)
    {
        users.RemoveAt(index);
    }

    // Method to get all users
    public static List<User> GetAllUsers()
    {
        return users;
    }
}