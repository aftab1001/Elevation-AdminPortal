import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedNewsResultRequestDto extends PagedFilterAndSortedRequest  {
    keyword: string
}
