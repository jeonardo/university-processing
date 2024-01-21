import { Result } from "./Result";

export class ResultWith<T> extends Result {
    constructor(
        success: boolean = false,
        title: null | string = null,
        errors: null | string[][] = null,
        object: null | T = null) {
        super(success, title, errors)
        this.Object = object
    }

    Object: null | T

    public static SuccessWith<T>(object: T): ResultWith<T> {
        return new ResultWith<T>(true, null, null, object);
    }

    public static FailWith<T>(
        title: null | string = null,
        errors: null | string[][] = null): ResultWith<T> {
        return new ResultWith(false, title, errors);
    }
}