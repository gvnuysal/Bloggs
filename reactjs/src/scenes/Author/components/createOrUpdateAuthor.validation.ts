import { L } from '../../../lib/abpUtility';

const authorRules = {
    name: [{ required: true, message: L('AuthorNameFieldIsRequired') }]
}

export default authorRules;