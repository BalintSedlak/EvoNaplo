import React from 'react'
import { Link } from 'react-router-dom'
import ReactCSSTransitionGroup from 'react-transition-group';
import classes from './UnauthorizedModal.module.css'

export const UnauthorizedModal = () => {
  return (
    <Link className={classes.linkStyle} to="/Components/Login/Login"><div className="alert alert-warning"><p>You must be logged in to continue.</p></div></Link>
    
  )
}
