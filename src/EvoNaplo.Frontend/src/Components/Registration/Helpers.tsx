import { isNonNullExpression } from "typescript";
import ISession from "../../ISession";

export function IsNullOrWhitespace(input: string) {
    return !input || !input.trim();
}

export function DoesImplementISession(object: any): object is ISession {
    return (object as ISession).id !== undefined
        && (object as ISession).name !== undefined
        && (object as ISession).role !== undefined;
}