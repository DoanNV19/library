export interface CommonResponse<T> {
  errorCode: number;
  errorMessage: string;
  success: boolean;
  data: T;
}

export interface DataPageList<T> {
  pageIndex: number;
  pageSize: number;
  totalRecord: number;
  totalPage: number;
  data: T[];
}

export interface CommonResponseList<T> {
  errorCode: number;
  errorMessage: string;
  success: boolean;
  data: T[];
}
export interface SearchCommonModel {
  keySearch?: string;
  pageIndex: number;
  pageSize?: number;
}

export interface DropdownModel {
  id: number;
  code?: string;
  name?: string;
}
