import { L } from '../../../lib/abpUtility';

const rules = {
  upperText: [{ required: true, message: L('ThisFieldIsRequired') }],
  headingText: [{ required: true, message: L('ThisFieldIsRequired') }],
  description: [{ required: true, message: L('ThisFieldIsRequired') }],
  type: [{  }],  
  image: [{}],
};

export default rules;
