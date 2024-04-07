import { DataPageList } from '../models/common.model';

export function pageLocal(dataList: any[], page_number: number, page_size: number): DataPageList<any> {
  const dataOut = [...dataList].slice((page_number - 1) * page_size, page_number * page_size);
  return {
    pageIndex: page_number,
    pageSize: page_size,
    total: dataList.length,
    data: dataOut ?? []
  };
}
