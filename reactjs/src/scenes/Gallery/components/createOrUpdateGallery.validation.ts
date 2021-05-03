import { L } from '../../../lib/abpUtility';

const rules = {
  imageTitle: [{ required: true, message: L('ThisFieldIsRequired') }],
  imageType: [{  }],  
  image: [{}],
};

export default rules;
