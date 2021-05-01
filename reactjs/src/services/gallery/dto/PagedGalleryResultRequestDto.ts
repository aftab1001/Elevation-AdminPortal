import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedGalleryResultRequestDto extends PagedFilterAndSortedRequest  {
    keyword: string
}
