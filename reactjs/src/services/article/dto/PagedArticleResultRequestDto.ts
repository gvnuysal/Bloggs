import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedArticleResultRequestDto extends PagedFilterAndSortedRequest {
    keyword: string;
    isActive: boolean;
    isDeleted: boolean;
}