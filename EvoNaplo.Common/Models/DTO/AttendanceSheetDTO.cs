﻿using EvoNaplo.Common.Models.Entities;
using System;

namespace EvoNaplo.Common.Models.DTO
{
    public class AttendanceSheetDTO
    {
        public int Id { get; set; }
        public DateTime MeetingDate { get; set; }
        public int ProjectId { get; set; }

        public AttendanceSheetDTO(AttendanceSheet attendanceSheet)
        {
            Id = attendanceSheet.Id;
            MeetingDate = attendanceSheet.MeetingDate;
            ProjectId = attendanceSheet.ProjectId;
        }
    }
}
