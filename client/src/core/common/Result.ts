export class Result {
    constructor(
        success: boolean = false,
        title: null | string = null,
        errors: null | string[][] = null) {
        this.Success = success
        this.Title = title
        this.Errors = errors
    }

    Success: boolean
    Title: null | string
    Errors: null | string[][]

    public static Success() {
        return new Result(true);
    }

    public static Fail(
        title: null | string = null,
        errors: null | string[][] = null): Result {
        return new Result(false, title, errors);
    }
}