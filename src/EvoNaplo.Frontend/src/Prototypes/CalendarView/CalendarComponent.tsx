// This code is imported from https://justacoding.blog/react-calendar-component-example-with-events/
// and I refactored some of it
import {Fragment, SetStateAction, useEffect, useState} from "react";
import ISession from "../../ISession";
import './CalendarComponent.css';

const MOCK_LOADING_TIME = 1000
const SAMPLE_META = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."

const MONTHS = [
  "Január",
  "Február",
  "Máricus",
  "Április",
  "Május",
  "Június",
  "Július",
  "Augusztus",
  "Szeptember",
  "Október",
  "November",
  "December"
]

const DAYS_SHORT = ["Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap"]

const toStartOfDay = (date) => {
	const newDate = new Date(date)
  newDate.setHours(0)
  newDate.setMinutes(0)
  newDate.setSeconds(0)
  newDate.setMilliseconds(0)
  return newDate
}

const pad = (input) => {
	return input < 10 ? "0" + input : input
}

const dateToInputFormat = (date) => {
	if (!date) {
  	return null
  }
  
	const month = pad(date.getMonth() + 1)
  const day = pad(date.getDate())
  const hours = pad(date.getHours())
  const minutes = pad(date.getMinutes())
  
  return `${date.getFullYear()}-${month}-${day}T${hours}:${minutes}`
}

const parseEvents = (events) => {
  return events.map(event => {
  	const from = new Date(event.dateFrom)
    const to = new Date(event.dateTo)

    return {
      ...event,
      from,
      to
    }
  })
}

const findEventsForDate = (events, date) => {
	const dateTime = date.getTime()

  return events.filter(event => {
    const eventFromTime = toStartOfDay(event.from).getTime()
    const eventToTime = toStartOfDay(event.to).getTime()

    return (dateTime >= eventFromTime && dateTime <= eventToTime)
  })
}

const Navigation = ({ date, setDate, setShowingEventForm }) => {
  return (
    <div className="navigation">
      <div className="back" onClick={() => {
          const newDate = new Date(date)
          newDate.setMonth(newDate.getMonth() - 1)
          setDate(newDate)
        }}>
          {"<-"} {MONTHS[date.getMonth() == 0 ? 11 : date.getMonth() - 1]}
      </div>

      <div className="classes.monthAndYear">
        {date.getFullYear()}. {MONTHS[date.getMonth()]}
      </div>

      <div className="forward" onClick={() => {
          const newDate = new Date(date)
          newDate.setMonth(newDate.getMonth() + 1)
          setDate(newDate)
        }}>
          {MONTHS[date.getMonth() == 11 ? 0 : date.getMonth() + 1]} {"->"}
      </div>
    </div>
  )
}

const DayLabels = () => {
  return <>{DAYS_SHORT.map((dayLabel, index) => {
    return <div className="dayLabel cell" key={index}>{dayLabel}</div>
  })}</>
}

const MiniEvent = ({ event, setViewingEvent }) => {
  return (
    <div
      className={`miniEvent ${event.type ? event.type.toLowerCase() : "standard"}`}
      onClick={() => setViewingEvent(event)}>
      {event.name}
    </div>
  )
}

const EventCalendar = ({ event, setViewingEvent, setShowingEventForm, deleteEvent }) => {
  return (
    <Modal onClose={() => setViewingEvent(null)} title={`${event.name} (${event.type})`} className="eventModal">
      <p>From <b>{event.dateFrom}</b> to <b>{event.dateTo}</b></p>
      <p>{event.meta}</p>

      <button ref="javascript:;" onClick={() => {
				setViewingEvent(null)
				setShowingEventForm({ visible: true, withEvent: event })
       }}>
        Change this event
      </button>
      
      <button className="red" ref="javascript:;" onClick={() => deleteEvent(event)}>
        Delete this event
      </button>

      <a className="close" href="javascript:;" onClick={() => setViewingEvent(null)}>Back to calendar</a>
    </Modal>
  )
}

const EventForm = ({ setShowingEventForm, addEvent, editEvent, withEvent, setViewingEvent, preselectedDate }) => {
  const newEvent = withEvent || {}
  if (!withEvent && !!preselectedDate) {
    newEvent.dateFrom = dateToInputFormat(preselectedDate)
  }
  const [event, setEvent] = useState(newEvent)

  return (
    <Modal onClose={() => setShowingEventForm({visible: false})}
           title={`${withEvent ? "Edit event" : "Add a new event"}`} className="aa">
      <div className="form">
        <label>Name
          <input type="text" placeholder="ie. My Event" defaultValue={event.name} onChange={(e) => setEvent({ ...event, name: e.target.value })} />
        </label>

        <label>Date from
          <input type="datetime-local" defaultValue={event.dateFrom || dateToInputFormat(preselectedDate)} onChange={(e) => setEvent({ ...event, dateFrom: e.target.value })} />
        </label>

        <label>Date to
          <input type="datetime-local" defaultValue={event.dateTo} onChange={(e) => setEvent({ ...event, dateTo: e.target.value })} />
        </label>

        <label>Type
          <select value={event.type ? event.type.toLowerCase() : "standard"} onChange={(e) => setEvent({ ...event, type: e.target.value })}>
            <option value="standard">Standard</option>
            <option value="busy">Busy</option>
            <option value="holiday">Holiday</option>
          </select>
        </label>

        <label>Description
          <input type="text" placeholder="Describe the event" defaultValue={event.meta} onChange={(e) => setEvent({ ...event, meta: e.target.value })} />
        </label>

        {withEvent ? (
        	<Fragment>
            <button onClick={() => editEvent(event)}>Edit event</button>
            <a className="close" href="javascript:;" onClick={() => {
            	setShowingEventForm({ visible: false })
            	setViewingEvent(event)}
            }>
              Cancel (go back to event view)
            </a>
          </Fragment>
        ) : (
        	<Fragment>
            <button onClick={() => addEvent(event)}>Add event to calendar</button>
            <a className="close" href="javascript:;" onClick={() => setShowingEventForm({ visible: false })}>Cancel (go back to calendar)</a>
          </Fragment>
        )}
      </div>
    </Modal>
  )
}

const Modal = ({ children, onClose, title, className }) => {
  return (
    <Fragment>
      <div className="overlay" onClick={onClose} />
      <div className={`modal ${className}`}>
        <h3>{title}</h3>
        <div className="inner">
          {children}
        </div>
      </div>
    </Fragment>
  )
}

const Loader = () => {
  return (
    <Fragment>
      <div className="overlay" />
      <div className="loader">
        <div className="lds-roller">
          <div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div>  
        </div>
      </div>
    </Fragment>
  )
}

const Grid = ({ date, events, setViewingEvent, setShowingEventForm, actualDate }) => {
  const ROWS_COUNT = 6
  const currentDate = toStartOfDay(new Date())
  const startingDate = new Date(date.getFullYear(), date.getMonth(), 1)
  startingDate.setDate(startingDate.getDate() - (startingDate.getDay() - 1))

  const dates: any[] = [];
  for (let i = 0; i < (ROWS_COUNT * 7); i++) {
    const date = new Date(startingDate)
    dates.push({ date, events: findEventsForDate(events, date) })
    startingDate.setDate(startingDate.getDate() + 1)
  }

  return (
    <Fragment>
      {dates.map((date, index) => {
        return (
          <div 
            key={index}
            className={`cell ${date.date.getTime() == currentDate.getTime() ? "current" : ""} ${date.date.getMonth() != actualDate.getMonth() ? "otherMonth" : ""}`
						}>
            <div className="date">
              {date.date.getDate()}<a href="javascript:;" className="addEventOnDay" onClick={() => setShowingEventForm({ visible: true, preselectedDate: date.date })}>+</a>
            </div>
            {date.events.map((event, index) =>
							<MiniEvent key={index} event={event} setViewingEvent={setViewingEvent} />
						)}
          </div>
        )
      })}
    </Fragment>
  )
}

const Calendar = ({ month, year, preloadedEvents = [] }) => {

  const selectedDate = new Date(year, month - 1)

  const [date, setDate] = useState(selectedDate)
  const [viewingEvent, setViewingEvent] = useState(false)
  const [showingEventForm, setShowingEventForm] = useState({ visible: false})
  const [isLoading, setIsLoading] = useState(false)
  const [feedback, setFeedback] = useState<SetStateAction<any> | null>(null);

  const parsedEvents = parseEvents(preloadedEvents)
  const [events, setEvents] = useState(parsedEvents)
  
  useEffect(() => {
  	console.log("Date has changed... Let's load some fresh data")
  }, [date])

  const addEvent = (event) => {
    setIsLoading(true)
    setShowingEventForm({ visible: false})
    setTimeout(() => {
      const parsedEvents = parseEvents([event])

      const updatedEvents = [...events]
      updatedEvents.push(parsedEvents[0])

      setEvents(updatedEvents)
      setIsLoading(false)
    }, MOCK_LOADING_TIME)
  }

  const editEvent = (event) => {
    setIsLoading(true)
    setShowingEventForm({ visible: false})

    setTimeout(() => {
      const parsedEvent = parseEvents([event])

      const updatedEvents = [...events].map(updatedEvent => {
        return updatedEvent.id === event.id ? parsedEvent[0] : updatedEvent
      })

      setEvents(updatedEvents)
      setIsLoading(false)
    }, MOCK_LOADING_TIME)
  }

  const deleteEvent = (event) => {
    setIsLoading(true)
    setViewingEvent(null)

    setTimeout(() => {
      const updatedEvents = [...events].filter(finalEvent => finalEvent.id != event.id)

      setEvents(updatedEvents)
      setIsLoading(false)

    }, MOCK_LOADING_TIME)
  }

  const {preselectedDate, withEvent, visible}: any = showingEventForm;
  return (
    <div className="calendar">
      {isLoading && <Loader />}



      <Navigation
        date={date}
        setDate={setDate}
        setShowingEventForm={setShowingEventForm}
      />

      <DayLabels/>

      <Grid
        date={date}
        events={events}
        setShowingEventForm={setShowingEventForm}
        setViewingEvent={setViewingEvent}
        actualDate={date}
      />

      {viewingEvent &&
        <EventCalendar
          event={viewingEvent}
          setShowingEventForm={setShowingEventForm}
          setViewingEvent={setViewingEvent}
          deleteEvent={deleteEvent}
        />
      }

      {showingEventForm && visible &&
        <EventForm
          withEvent={withEvent}
          preselectedDate={preselectedDate}
          setShowingEventForm={setShowingEventForm}
          addEvent={addEvent}
          editEvent={editEvent}
          setViewingEvent={setViewingEvent}
        />
      }
    </div>
  )
}

const CalendarComponent = ({ session }: { session: ISession }) => {

  return (<Calendar
    month={7}
    year={2022}
    preloadedEvents={[
      {
        id: 1,
        name: "Foglalkozás",
        dateFrom: "2022-07-01T14:30",
        dateTo: "2022-07-01T15:30",
        meta: SAMPLE_META,
        type: "Meeting"
      },
      {
        id: 2,
        name: "Foglalkozás",
        dateFrom: "2022-07-08T14:30",
        dateTo: "2022-07-08T15:30",
        meta: SAMPLE_META,
        type: "Meeting"
      },{
        id: 3,
        name: "Szemeszterzáró",
        dateFrom: "2022-07-14T14:30",
        dateTo: "2022-07-14T15:30",
        meta: SAMPLE_META,
        type: "Holiday"
      }]}/>)
}

export default CalendarComponent;

/*preloadedEvents={[
      {
        id: 1,
        name: "Holiday",
        dateFrom: "2021-09-29T12:00",
        dateTo: "2021-10-03T08:45",
        meta: SAMPLE_META,
        type: "Holiday"
      },
      {
        id: 2,
        name: "Meeting",
        dateFrom: "2021-10-01T09:45",
        dateTo: "2021-10-04T22:00",
        meta: SAMPLE_META,
        type: "Standard"
      },
      {
        id: 3,
        name: "Away",
        dateFrom: "2021-10-01T01:00",
        dateTo: "2021-10-01T23:59",
        meta: SAMPLE_META,
        type: "Busy"
      },
      {
        id: 4,
        name: "Inspection",
        dateFrom: "2021-10-19T07:30",
        dateTo: "2021-10-21T23:59",
        meta: SAMPLE_META,
        type: "Standard"
      },
      {
        id: 5,
        name: "Holiday - Greece",
        dateFrom: "2021-10-14T08:00",
        dateTo: "2021-10-16T23:59",
        meta: SAMPLE_META,
        type: "Holiday"
      },
      {
        id: 6,
        name: "Holiday - Spain",
        dateFrom: "2021-10-29T08:00",
        dateTo: "2021-10-31T23:59",
        meta: SAMPLE_META,
        type: "Holiday"
      }
    ]} */