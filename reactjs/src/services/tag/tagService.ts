import { GetAllTagOutput } from './dto/getAllTagOutput';
import { PagedTagResultRequestDto } from './dto/PagedTagResultRequestDto';
import http from '../httpService';
import { PagedResultDto } from '../dto/pagedResultDto';
import { EntityDto } from '../dto/entityDto';
import { GetTagForUpdateOutput } from './dto/getTagForUpdateOutput';
import { CreateTagInput } from './dto/createTagInput';
import { UpdateTagInput } from './dto/updateTagInput';

class TagService {
    public async getAll(pagedFilterAndSortedRequest: PagedTagResultRequestDto): Promise<PagedResultDto<GetAllTagOutput>> {
        let result = await http.get('/api/services/app/Tag/GetAll', { params: pagedFilterAndSortedRequest });
        return result.data.result;
    }
    public async getTagForEdit(entityDto: EntityDto): Promise<GetTagForUpdateOutput> {
        let result = await http.get('api/services/app/Tag/GetTagForUpdate', { params: entityDto });
        return result.data.result;
    }
    public async create(createTagInput: CreateTagInput) {
        let result = await http.post('api/services/app/Tag/Create', createTagInput)
        return result.data;
    }
    public async update(updateTagInput: UpdateTagInput) {
        let result = await http.put('api/services/app/Tag/Update', updateTagInput);
        return result.data;
    }
    public async delete(entityDto: EntityDto) {
        let result = await http.delete('api/services/app/Tag/Delete', { params: entityDto });
        return result.data;
    }
}

export default new TagService();