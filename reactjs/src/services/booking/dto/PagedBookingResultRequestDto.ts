import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedBookingResultRequestDto extends PagedFilterAndSortedRequest  {
    keyword: string
}
