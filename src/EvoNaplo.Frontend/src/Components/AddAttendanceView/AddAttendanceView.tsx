import React from "react";
import ISession from "../../ISession";
import { UnauthorizedModal } from "../UI/UnauthorizedModal";
import { AddAttendanceForm } from "./AddAttendanceForm";

const DUMMY_DATA = [
  {
    id: 1,
    project: "EvoNaplo",
  },
  {
    id: 2,
    project: "EvoRPG",
  },
];

export const AddAttendanceView = ({ session }: { session: ISession }) => {
  if (session.id > 0) {
    return <AddAttendanceForm ActualProjects={DUMMY_DATA} />;
  }
  return <UnauthorizedModal />;
};
