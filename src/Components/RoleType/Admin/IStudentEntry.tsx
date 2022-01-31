import React, { useState } from 'react';

interface IStudentEntry {
    fullname: string;
    email: string;
    phoneNumber: string;
    semester: string;
    project: string;
    mentors: string;
    dateOfClass: string;
    typeOfClass: string;
    technology: string;
    isInFacebookGroup: boolean;
    isAppliedForScholarship: boolean;
    isAppliedForSummerJob: boolean;
    participationPercent: number;
  }

  export default IStudentEntry;