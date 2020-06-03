import { observable, action } from 'mobx';

import { PagedResultDto } from '../services/dto/pagedResultDto';
import { GetAllArticleOutput } from '../services/article/dto/getAllArticleOutput';
import articleService from '../services/article/articleService';
import { PagedArticleResultRequestDto } from '../services/article/dto/PagedArticleResultRequestDto';
import ArticleEditModel from '../models/Article/articleEditModel';
import { EntityDto } from '../services/dto/entityDto';
import { CreateArticleInput } from '../services/article/dto/createArticleInput';
import { UpdateArticleInput } from '../services/article/dto/updateArticleInput';

class ArticleStore {
    @observable articles!: PagedResultDto<GetAllArticleOutput>;
    @observable articleEdit: ArticleEditModel = new ArticleEditModel();

    @action async getAll(pagedFilterAndSortedRequest: PagedArticleResultRequestDto) {
        let result = await articleService.getAll(pagedFilterAndSortedRequest);
        this.articles = result;
    }
    @action async createArticle() {
        this.articleEdit = {
            article: {
                id: 0,
                title: '',
                contents: '',
                authorId: 0,
                categoryId: 0,
                isActive: true
            }
        }
    }
    @action async getArticleForEdit(entityDto: EntityDto) {
        let result = await articleService.getArticleForEdit(entityDto);
        this.articleEdit.article = result.article;
    }
    @action async create(createArticleInput: CreateArticleInput) {
        await articleService.create(createArticleInput);
    }

    @action async update(updateArticleInput: UpdateArticleInput) {
        await articleService.update(updateArticleInput);
    }
    @action  async delete(entityDto: EntityDto) {

        await articleService.delete(entityDto);
        this.articles.items = this.articles.items.filter((x: GetAllArticleOutput) => x.id !== entityDto.id);
    }
}

export default ArticleStore;