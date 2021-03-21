import { L } from '../../../lib/abpUtility';

const rules = {
  price: [{ required: true, message: L('ThisFieldIsRequired') }],
  name: [{ required: true, message: L('ThisFieldIsRequired') }],
  
};

export default rules;
