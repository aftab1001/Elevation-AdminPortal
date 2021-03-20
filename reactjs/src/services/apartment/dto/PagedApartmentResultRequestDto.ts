import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedApartmentResultRequestDto extends PagedFilterAndSortedRequest  {
    keyword: string
}
