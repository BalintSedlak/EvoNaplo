import React, { useState } from 'react';
import ICardContent from './ICardContent';

interface IColumn {
    id: number;
    title: string;
    cards: Array<ICardContent>;
  }

  export default IColumn;