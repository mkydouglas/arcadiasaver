import { AddHeroDto } from './AddHeroDto';

export class GetTeamsDto {
    id:    number;
    name:  string;
    goals: any[];
    heros: AddHeroDto[];
}