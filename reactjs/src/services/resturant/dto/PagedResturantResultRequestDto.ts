import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedResturantResultRequestDto extends PagedFilterAndSortedRequest  {
    keyword: string
}
