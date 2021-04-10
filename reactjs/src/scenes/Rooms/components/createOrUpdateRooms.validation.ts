import { L } from '../../../lib/abpUtility';

const rules = {
  price: [{ required: true, message: L('ThisFieldIsRequired') }],
  name: [{ required: true, message: L('ThisFieldIsRequired') }],
  bed: [{ required: true, message: L('ThisFieldIsRequired') }],
  bath: [{ required: true, message: L('ThisFieldIsRequired') }],
  length: [{ required: true, message: L('ThisFieldIsRequired') }],
  categoryName: [{ required: true, message: L('ThisFieldIsRequired') }],
  description: [{  }],
  image: [{  }],
  
};

export default rules;
