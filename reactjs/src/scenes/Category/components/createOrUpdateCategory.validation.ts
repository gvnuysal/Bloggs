import { L } from '../../../lib/abpUtility';

const categoryRules = {
    name: [{ required: true, message: L('CategoryNameFieldIsRequired') }]
}

export default categoryRules;