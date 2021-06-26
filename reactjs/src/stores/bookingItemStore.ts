import { action, observable } from 'mobx';
import BookingItemModel from './../models/Bookings/BookingItemsModel';
import bookingService from '../services/booking/bookingService';
import { EntityDtoByType } from './../services/dto/entityDtoByType';


class BookingItemStore {  
  @observable bookingItemModel: BookingItemModel = new BookingItemModel();

  @action
  async createBookingItem() {
    this.bookingItemModel = {       
      itemId: 0,
      Name: '',
      Price: 0
    };
  }  

  @action
  async getItems(entityDtoByType: EntityDtoByType) {
    let result = await bookingService.getItemByType(entityDtoByType);
    this.bookingItemModel = result;
  }

 
}

export default BookingItemStore;
