import { GetAllCategoryOutput } from './dto/getAllCategoryOutput';
import { PagedCategoryResultRequestDto } from './dto/PagedCategoryResultRequestDto';
import http from '../httpService';
import { PagedResultDto } from '../dto/pagedResultDto';

class CategoryService {
    public async getAll(pagedFilterAndSortedRequest: PagedCategoryResultRequestDto): Promise<PagedResultDto<GetAllCategoryOutput>> {
        let result = await http.get('/api/services/app/Category/GetAll', { params: pagedFilterAndSortedRequest });
        return result.data.result;
    }
}

export default new CategoryService();