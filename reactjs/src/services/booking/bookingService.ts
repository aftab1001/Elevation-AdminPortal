import CreateBookingInput from './dto/createBookingInput';
import CreateBookingOutput from './dto/createBookingOutput';
import { EntityDto } from '../dto/entityDto';
import { GetAllBookingOutput } from './dto/getAllBookingOutput';
import GetBookingOutput from './dto/getBookingOutput';
import { PagedResultDto } from '../dto/pagedResultDto';
import { PagedBookingResultRequestDto } from './dto/PagedBookingResultRequestDto';
import UpdateBookingInput from './dto/updateBookingInput';
import UpdateBookingOutput from './dto/updateBookingOutput';
import http from '../httpService';
import GetBookingItemOutput from './dto/getBookingItemOutput';
import { EntityDtoByType } from './../dto/entityDtoByType';

class BookingService {
  public async create(createBookingInput: CreateBookingInput): Promise<CreateBookingOutput> {
    let result = await http.post('api/services/app/Booking/Create', createBookingInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/Booking/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetBookingOutput> {
    let result = await http.get('api/services/app/Booking/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(
    pagedFilterAndSortedRequest: PagedBookingResultRequestDto
  ): Promise<PagedResultDto<GetAllBookingOutput>> {
    let result = await http.get('api/services/app/Booking/GetAllBookings', {
      params: pagedFilterAndSortedRequest,
    });
    return result.data.result;
  }

  public async update(updateBookingInput: UpdateBookingInput): Promise<UpdateBookingOutput> {
    let result = await http.put('api/services/app/Booking/Update', updateBookingInput);
    return result.data.result;
  }

  public async getItemByType(EntityDtoByType: EntityDtoByType): Promise<GetBookingItemOutput> {
    let result = await http.get('api/services/app/Booking/GetBookingByType', { params: EntityDtoByType });
    return result.data.result;
  }
}

export default new BookingService();
