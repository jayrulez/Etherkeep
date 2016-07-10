import { IdentityType } from '../common/identity-type';

export class ResetPasswordModel
{
	public identityType: IdentityType;
	public emailAddress: string;
}