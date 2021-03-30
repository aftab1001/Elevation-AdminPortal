import CreateNewsInput from './dto/createNewsInput';
import CreateNewsOutput from './dto/createNewsOutput';
import { EntityDto } from '../dto/entityDto';
import { GetAllNewsOutput } from './dto/getAllNewsOutput';
import GetNewsOutput from './dto/getNewsOutput';
import { PagedResultDto } from '../dto/pagedResultDto';
import {PagedNewsResultRequestDto} from './dto/PagedNewsResultRequestDto';
import UpdateNewsInput from './dto/updateNewsInput';
import UpdateNewsOutput from './dto/updateNewsOutput';
import http from '../httpService';

class NewsService {
  public async create(createNewsInput: CreateNewsInput): Promise<CreateNewsOutput> {
    let result = await http.post('api/services/app/News/Create', createNewsInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/News/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetNewsOutput> {
    let result = await http.get('api/services/app/News/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedNewsResultRequestDto): Promise<PagedResultDto<GetAllNewsOutput>> {
    let result = await http.get('api/services/app/News/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateNewsInput: UpdateNewsInput): Promise<UpdateNewsOutput> {
    let result = await http.put('api/services/app/News/Update', updateNewsInput);
    return result.data.result;
  }
}

export default new NewsService();
