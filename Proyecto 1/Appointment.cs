﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto_1
{
    [Serializable]
    public class Appointment
    {
        #region Properties
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }
        public List<User> InvitedUsers { get; } = new List<User>();

        #endregion
        public Appointment(string title, DateTime date, DateTime startTime, DateTime endTime, string description,User creator, List<User> users)
        {
            Title = title;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
            Creator = creator;
            if(users != null)
            {
                foreach (User user in users)
                {
                    InvitedUsers.Add(user);
                }
            }
            
        }
        public override string ToString()
        {
            return Title;
        }

        public bool HasUser(User user)
        {
            if (user == null)
            {
                return false;
            }
            if (Creator.Email == user.Email)
            {
                return true;
            }
            foreach (User inviteduser in InvitedUsers)
            {
                if (inviteduser.Email == user.Email)
                {
                    return true;
                }

            }
            
            return false;

        }

        public int Duration()
        {
            TimeSpan difference = EndTime - StartTime;
            int duration = (int)difference.TotalMinutes/60;
            return duration;
        }

    }
}
