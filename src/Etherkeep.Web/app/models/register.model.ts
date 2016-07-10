import { IdentityType } from '../common/identity-type';

export class RegisterModel
{
	public identityType: IdentityType;
	public countryCallingCode: string;
	public areaCode: string;
	public subscriberNumber: string;
	public emailAddress: string;
	public password: string;
	public firstName: string;
	public lastName: string;
}