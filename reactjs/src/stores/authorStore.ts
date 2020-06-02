import { observable, action } from 'mobx';

import { PagedResultDto } from '../services/dto/pagedResultDto';
import { GetAllAuthorOutput } from '../services/author/dto/getAllAuthorOutput';
import authorService from '../services/author/authorService';
import { PagedAuthorResultRequestDto } from '../services/author/dto/PagedAuthorResultRequestDto';
import AuthorEditModel from '../models/Author/authorEditModel';
import { EntityDto } from '../services/dto/entityDto';
import { CreateAuthorInput } from '../services/author/dto/createAuthorInput';
import { UpdateAuthorInput } from '../services/author/dto/updateAuthorInput';

class AuthorStore {
    @observable authors!: PagedResultDto<GetAllAuthorOutput>;
    @observable authorEdit: AuthorEditModel = new AuthorEditModel();

    @action async getAll(pagedFilterAndSortedRequest: PagedAuthorResultRequestDto) {
        let result = await authorService.getAll(pagedFilterAndSortedRequest);
        this.authors = result;
    }
    @action async createAuthor() {
        this.authorEdit = {
            author: {
                id: 0,
                isActive: true
            }
        }
    }
    @action async getAuthorForEdit(entityDto: EntityDto) {
        let result = await authorService.getAuthorForEdit(entityDto);
        this.authorEdit.author = result.author;
    }
    @action async create(createAuthorInput: CreateAuthorInput) {
        await authorService.create(createAuthorInput);
    }

    @action async update(updateAuthorInput: UpdateAuthorInput) {
        await authorService.update(updateAuthorInput);
    }
    @action  async delete(entityDto: EntityDto) {

        await authorService.delete(entityDto);
        this.authors.items = this.authors.items.filter((x: GetAllAuthorOutput) => x.id !== entityDto.id);
    }
}

export default AuthorStore;