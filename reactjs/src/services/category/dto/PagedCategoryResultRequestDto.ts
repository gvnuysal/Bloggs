import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedCategoryResultRequestDto extends PagedFilterAndSortedRequest {
    keyword: string;
    isActive:boolean;
    isDeleted:boolean;
}