import { observable, action } from 'mobx';

import { PagedResultDto } from '../services/dto/pagedResultDto';
import { GetAllTagOutput } from '../services/tag/dto/getAllTagOutput';
import tagService from '../services/tag/tagService';
import { PagedTagResultRequestDto } from '../services/tag/dto/PagedTagResultRequestDto';
import TagEditModel from '../models/Tag/tagEditModel';
import { EntityDto } from '../services/dto/entityDto';
import { CreateTagInput } from '../services/tag/dto/createTagInput';
import { UpdateTagInput } from '../services/tag/dto/updateTagInput';

class TagStore {
    @observable tags!: PagedResultDto<GetAllTagOutput>;
    @observable tagEdit: TagEditModel = new TagEditModel();

    @action async getAll(pagedFilterAndSortedRequest: PagedTagResultRequestDto) {
        let result = await tagService.getAll(pagedFilterAndSortedRequest);
        this.tags = result;
    }
    @action async createTag() {
        this.tagEdit = {
            tag: {
                id: 0,
                name: '',
            }
        }
    }
    @action async getTagForEdit(entityDto: EntityDto) {
        let result = await tagService.getTagForEdit(entityDto);
        this.tagEdit.tag = result.tag;
    }
    @action async create(createTagInput: CreateTagInput) {
        await tagService.create(createTagInput);
    }

    @action async update(updateTagInput: UpdateTagInput) {
        await tagService.update(updateTagInput);
    }
    @action  async delete(entityDto: EntityDto) {

        await tagService.delete(entityDto);
        this.tags.items = this.tags.items.filter((x: GetAllTagOutput) => x.id !== entityDto.id);
    }
}

export default TagStore;