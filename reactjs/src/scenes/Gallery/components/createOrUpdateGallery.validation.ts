import { L } from '../../../lib/abpUtility';

const rules = {
  imageTitle: [{ required: true, message: L('ThisFieldIsRequired') }],
  type: [{ required: true, message: L('ThisFieldIsRequired') }],  
  image: [{}],
};

export default rules;
