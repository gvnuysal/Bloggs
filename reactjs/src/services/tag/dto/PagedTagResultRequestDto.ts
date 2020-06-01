import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedTagResultRequestDto extends PagedFilterAndSortedRequest {
    keyword: string;
    isDeleted:boolean;
}