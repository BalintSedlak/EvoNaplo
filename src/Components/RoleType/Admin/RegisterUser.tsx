import React, { useState } from 'react';

const RegisterUser = () => {
  return (
    <div>
      <h1>
        Register user
      </h1>
    <form>
      <label> 
        First Name: 
        <input type="text" name="firstname" /> 
      </label>

      <label> 
        Last Name: 
        <input type="text" name="lastname" /> 
      </label>

      <label> 
        Email: 
        <input type="email" name="email" /> 
      </label>

      <label> 
        Phone number: 
        <input type="tel" name="phonenumber" /> 
      </label>

      <label>
        Role:
        <select>
          <option value="0">Admin</option>
          <option value="1">Mentor</option>
          <option selected value="2">Student</option>
        </select>
      </label>

      <input type="submit" value="Submit" />
    </form>
    </div>
  )
}

export default RegisterUser;