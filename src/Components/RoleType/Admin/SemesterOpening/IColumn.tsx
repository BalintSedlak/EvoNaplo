import React, { useState } from 'react';
import IStudent from './IStudent';

interface IColumn {
    id: number;
    title: string;
    students: Array<IStudent>;
  }

  export default IColumn;