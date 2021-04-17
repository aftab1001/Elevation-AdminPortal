import { L } from '../../../lib/abpUtility';

const rules = {
  name: [{ required: true, message: L('ThisFieldIsRequired') }],
  categoryName: [{ required: true, message: L('ThisFieldIsRequired') }],
  price: [{ required: true, message: L('ThisFieldIsRequired') }],
  bed: [{ required: true, message: L('ThisFieldIsRequired') }],
  bath: [{ required: true, message: L('ThisFieldIsRequired') }],
  length: [{ required: true, message: L('ThisFieldIsRequired') }],
  description: [{}],
  location: [{}],
  features: [{}],
  facilities: [{}],
  nightlyPlan: [{}],
  weekendPlan: [{}],
  weeklyPlan: [{}],
  monthlyPlan: [{}],
  cleaningFee: [{}],
  cityFee: [{}],
  maxNumberOfDays: [{}],
  minNumberOfDays: [{}],
  image: [{}],
};

export default rules;
