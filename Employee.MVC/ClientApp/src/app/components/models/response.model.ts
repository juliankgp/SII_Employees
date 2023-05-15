export class ResponseModel<T> {
    successfully!: boolean;
    description?: string;
    result!: T;
  }