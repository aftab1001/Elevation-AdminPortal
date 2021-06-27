import { L } from '../../../lib/abpUtility';

const rules = {
  price: [{ required: true, message: L('ThisFieldIsRequired') }],
  fromDate: [{ required: true, message: L('ThisFieldIsRequired') }],
  toDate: [{ required: true, message: L('ThisFieldIsRequired') }],
  firstName: [{ required: true, message: L('ThisFieldIsRequired') }],
  lastName: [{ required: true, message: L('ThisFieldIsRequired') }],
  contactNumber: [{ required: true, message: L('ThisFieldIsRequired') }],
  roomType:[],
  email: [],
  specialRequest: [],
  pricePaid: [],
  bookingType: [],
  adminComments: []  ,
  bookingStatus:[]
};

export default rules;
