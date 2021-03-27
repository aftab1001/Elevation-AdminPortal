import { L } from '../../../lib/abpUtility';

const rules = {  
  name: [{ required: true, message: L('ThisFieldIsRequired') }],
  price: [{ required: true, message: L('ThisFieldIsRequired') }],
  bed: [{ required: true, message: L('ThisFieldIsRequired') }],
  bath: [{ required: true, message: L('ThisFieldIsRequired') }],
  length: [{ required: true, message: L('ThisFieldIsRequired') }],
  
};

export default rules;
