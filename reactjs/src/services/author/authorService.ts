import { GetAllAuthorOutput } from './dto/getAllAuthorOutput';
import { PagedAuthorResultRequestDto } from './dto/PagedAuthorResultRequestDto';
import http from '../httpService';
import { PagedResultDto } from '../dto/pagedResultDto';
import { EntityDto } from '../dto/entityDto';
import { GetAuthorForUpdateOutput } from './dto/getAuthorForUpdateOutput';
import { CreateAuthorInput } from './dto/createAuthorInput';
import { UpdateAuthorInput } from './dto/updateAuthorInput';

class AuthorService {
    public async getAll(pagedFilterAndSortedRequest: PagedAuthorResultRequestDto): Promise<PagedResultDto<GetAllAuthorOutput>> {
        let result = await http.get('/api/services/app/Author/GetAll', { params: pagedFilterAndSortedRequest });
        return result.data.result;
    }
    public async getAuthorForEdit(entityDto: EntityDto): Promise<GetAuthorForUpdateOutput> {
        let result = await http.get('api/services/app/Author/GetAuthorForUpdate', { params: entityDto });
        return result.data.result;
    }
    public async create(createAuthorInput: CreateAuthorInput) {
        let result = await http.post('api/services/app/Author/Create', createAuthorInput)
        return result.data;
    }
    public async update(updateAuthorInput:UpdateAuthorInput){
        let result=await http.put('api/services/app/Author/Update',updateAuthorInput);
        return result.data;
    }
    public async delete(entityDto: EntityDto) {
        let result = await http.delete('api/services/app/Author/Delete', { params: entityDto });
        return result.data;
      }
}

export default new AuthorService();