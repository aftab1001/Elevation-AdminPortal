import { action, observable } from 'mobx';
import CreateBookingInput from '../services/booking/dto/createBookingInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllBookingOutput } from '../services/booking/dto/getAllBookingOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedBookingResultRequestDto } from '../services/booking/dto/PagedBookingResultRequestDto';
import BookingModel from '../models/Bookings/BookingModel';
import UpdateBookingInput from '../services/booking/dto/updateBookingInput';
import bookingService from '../services/booking/bookingService';

class BookingStore {
  @observable bookings!: PagedResultDto<GetAllBookingOutput>;
  @observable bookingModel: BookingModel = new BookingModel();

  @action
  async create(createBookingInput: CreateBookingInput) {
    await bookingService.create(createBookingInput);
  }

  @action
  async createBooking() {
    this.bookingModel = {
      roomName: '',
      fromDate: '',
      toDate: '',
      guestName: '',
      guestContact: '',
      guestEmail: '',
      specialRequest: '',
      pricePaid: 0,
      bookingType: '',
      bookingStatus: '',
      adminComments: '',
      itemId: '',
      itemType: '',
      id: 0,
    };
  }

  @action
  async update(updateBookingInput: UpdateBookingInput) {
    let result = await bookingService.update(updateBookingInput);

    this.bookings.items = this.bookings.items.map((x: GetAllBookingOutput) => {
      if (x.id === updateBookingInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await bookingService.delete(entityDto);
    this.bookings.items = this.bookings.items.filter(
      (x: GetAllBookingOutput) => x.id !== entityDto.id
    );
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await bookingService.get(entityDto);
    this.bookingModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedBookingResultRequestDto) {
    let result = await bookingService.getAll(pagedFilterAndSortedRequest);
    this.bookings = result;
  }
}

export default BookingStore;
