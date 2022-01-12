import React, { useState } from 'react';

const CreateStudent = () => {
  const [count, setCount] = useState(0);
  const incrementCount = () => setCount(count + 1);

  return (
    <div>
      <h1>
        Register as student
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
        Password: 
        <input type="password" name="password" /> 
      </label>

      <label> 
        Repeat Password: 
        <input type="password" name="repeatpassword" /> 
      </label>

      <input type="submit" value="Submit" />
    </form>
    </div>
  )
}

export default CreateStudent;