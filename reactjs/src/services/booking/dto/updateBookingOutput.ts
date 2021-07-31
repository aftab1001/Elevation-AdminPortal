export default interface UpdateBookingOutput {
  roomName: string;
  fromDate: string;
  toDate: string;
  guestName: string;
  guestContact: string;
  guestEmail: string;
  specialRequest: string;
  price: number;
  bookingType: string;
  bookingStatus: string;
  adminComments: string;
  itemId: string;
  itemType: string;
  id: number;
}
