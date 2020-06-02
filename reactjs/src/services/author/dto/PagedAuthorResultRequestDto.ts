import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedAuthorResultRequestDto extends PagedFilterAndSortedRequest {
    FullName: string;
    isActive: boolean;
    isDeleted: boolean;
}