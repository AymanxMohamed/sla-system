export default interface Result<T> {
    value: T,
    isSuccess: boolean;
    isFailure: boolean;
    error: Error;
}