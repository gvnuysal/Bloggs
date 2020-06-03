import { L } from '../../../lib/abpUtility';

const articleRules = {
    title: [{ required: true, message: L('ArticleTitleFieldIsRequired') }],
    contents: [{ required: true, message: L('ArticleContentFieldIsRequired') }],
    categoryId: [{ required: true, message: L('CategoryFieldIsRequired') }]
}

export default articleRules;