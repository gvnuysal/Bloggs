import { GetAllCategoryOutput } from './dto/getAllCategoryOutput';
import { PagedCategoryResultRequestDto } from './dto/PagedCategoryResultRequestDto';
import http from '../httpService';
import { PagedResultDto } from '../dto/pagedResultDto';
import { EntityDto } from '../dto/entityDto';
import { GetCategoryForUpdateOutput } from './dto/getCategoryForUpdateOutput';
import { CreateCategoryInput } from './dto/createCategoryInput';
import { UpdateCategoryInput } from './dto/updateCategoryInput';

class CategoryService {
    public async getAll(pagedFilterAndSortedRequest: PagedCategoryResultRequestDto): Promise<PagedResultDto<GetAllCategoryOutput>> {
        let result = await http.get('/api/services/app/Category/GetAll', { params: pagedFilterAndSortedRequest });
        return result.data.result;
    }
    public async getCategoryForEdit(entityDto: EntityDto): Promise<GetCategoryForUpdateOutput> {
        let result = await http.get('api/services/app/Category/GetCategoryForUpdate', { params: entityDto });
        return result.data.result;
    }
    public async create(createCategoryInput: CreateCategoryInput) {
        let result = await http.post('api/services/app/Category/Create', createCategoryInput)
        return result.data;
    }
    public async update(updateCategoryInput:UpdateCategoryInput){
        let result=await http.put('api/services/app/Category/Update',updateCategoryInput);
        return result.data;
    }
    public async delete(entityDto: EntityDto) {
        let result = await http.delete('api/services/app/Category/Delete', { params: entityDto });
        return result.data;
      }
}

export default new CategoryService();