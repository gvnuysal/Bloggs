import { GetAllArticleOutput } from './dto/getAllArticleOutput';
import { PagedArticleResultRequestDto } from './dto/PagedArticleResultRequestDto';
import http from '../httpService';
import { PagedResultDto } from '../dto/pagedResultDto';
import { EntityDto } from '../dto/entityDto';
import { GetArticleForUpdateOutput } from './dto/getArticleForUpdateOutput';
import { CreateArticleInput } from './dto/createArticleInput';
import { UpdateArticleInput } from './dto/updateArticleInput';

class ArticleService {
    public async getAll(pagedFilterAndSortedRequest: PagedArticleResultRequestDto): Promise<PagedResultDto<GetAllArticleOutput>> {
        let result = await http.get('/api/services/app/Article/GetAll', { params: pagedFilterAndSortedRequest });
        return result.data.result;
    }
    public async getArticleForEdit(entityDto: EntityDto): Promise<GetArticleForUpdateOutput> {
        let result = await http.get('api/services/app/Article/GetArticleForUpdate', { params: entityDto });
        return result.data.result;
    }
    public async create(createArticleInput: CreateArticleInput) {
        let result = await http.post('api/services/app/Article/Create', createArticleInput)
        return result.data;
    }
    public async update(updateArticleInput: UpdateArticleInput) {
        let result = await http.put('api/services/app/Article/Update', updateArticleInput);
        return result.data;
    }
    public async delete(entityDto: EntityDto) {
        let result = await http.delete('api/services/app/Article/Delete', { params: entityDto });
        return result.data;
    }
}

export default new ArticleService();