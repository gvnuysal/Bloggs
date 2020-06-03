
import AuthorModel from '../Author/authorModel';
import CategoryModel from '../Category/categoryModel';

class ArticleModel {
    title!: string;
    isActive?: boolean;
    contents!: string;
    id!: number;
    authorId!: number;
    categoryId!: number;
    author?: AuthorModel = new AuthorModel();
    category?: CategoryModel = new CategoryModel();
}

export default ArticleModel;