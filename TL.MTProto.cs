using System;

namespace TL
{
	[TLDef(0x5162463, "resPQ#05162463 nonce:int128 server_nonce:int128 pq:bytes server_public_key_fingerprints:Vector<long> = ResPQ")]
	public class ResPQ : ITLObject
	{
		public Int128 nonce;
		public Int128 server_nonce;
		public byte[] pq;
		public long[] server_public_key_fingerprints;
	}

	[TLDef(0X83C95AEC, "p_q_inner_data# pq:string p:string q:string nonce:int128 server_nonce:int128 new_nonce:int256 = P_Q_inner_data")]
	public class PQInnerData : ITLObject
	{
		public byte[] pq;
		public byte[] p;
		public byte[] q;
		public Int128 nonce;
		public Int128 server_nonce;
		public Int256 new_nonce;
	}
	[TLDef(0xA9F55F95, "p_q_inner_data_dc#a9f55f95 pq:bytes p:bytes q:bytes nonce:int128 server_nonce:int128 new_nonce:int256 dc:int = P_Q_inner_data")]
	public class PQInnerDataDC : PQInnerData
	{
		public int dc;
	}
	[TLDef(0x56FDDF88, "p_q_inner_data_temp_dc#56fddf88 pq:bytes p:bytes q:bytes nonce:int128 server_nonce:int128 new_nonce:int256 dc:int expires_in:int = P_Q_inner_data")]
	public class PQInnerDataTempDC : PQInnerData
	{
		public int dc;
		public int expires_in;	// seconds
	}

	public abstract class ServerDHParams : ITLObject
	{
		public Int128 nonce;
		public Int128 server_nonce;
	}
	[TLDef(0X79CB045D, "server_DH_params_fail#79cb045d nonce:int128 server_nonce:int128 new_nonce_hash:int128 = Server_DH_Params")]
	public class ServerDHParamsFail : ServerDHParams { public Int128 new_nonce_hash; }
	[TLDef(0XD0E8075C, "server_DH_params_ok#d0e8075c nonce:int128 server_nonce:int128 encrypted_answer:bytes = Server_DH_Params")]
	public class ServerDHParamsOk : ServerDHParams { public byte[] encrypted_answer; }

	[TLDef(0xB5890DBA, "server_DH_inner_data#b5890dba nonce:int128 server_nonce:int128 g:int dh_prime:bytes g_a:bytes server_time:int = Server_DH_inner_data")]
	public class ServerDHInnerData : ITLObject
	{
		public Int128 nonce;
		public Int128 server_nonce;
		public int g;
		public byte[] dh_prime;
		public byte[] g_a;
		public DateTime server_time;
	}

	[TLDef(0x6643B654, "client_DH_inner_data#6643b654 nonce:int128 server_nonce:int128 retry_id:long g_b:bytes = Client_DH_Inner_Data")]
	public class ClientDHInnerData : ITLObject
	{
		public Int128 nonce;
		public Int128 server_nonce;
		public long retry_id;
		public byte[] g_b;
	}

	public abstract class SetClientDHParamsAnswer : ITLObject
	{
		public Int128 nonce;
		public Int128 server_nonce;
		public Int128 new_nonce_hashN; // 16 low order bytes from SHA1(new_nonce + (01=ok, 02=retry, 03=fail) + 8 high order bytes from SHA1(auth_key))
	}
	[TLDef(0x3BCBF734, "dh_gen_ok#3bcbf734 nonce:int128 server_nonce:int128 new_nonce_hash1:int128 = Set_client_DH_params_answer")]
	public class DHGenOk : SetClientDHParamsAnswer { }
	[TLDef(0x46DC1FB9, "dh_gen_retry#46dc1fb9 nonce:int128 server_nonce:int128 new_nonce_hash2:int128 = Set_client_DH_params_answer")]
	public class DHGenRetry : SetClientDHParamsAnswer { }
	[TLDef(0xA69DAE02, "dh_gen_fail#a69dae02 nonce:int128 server_nonce:int128 new_nonce_hash3:int128 = Set_client_DH_params_answer")]
	public class DHGenFail : SetClientDHParamsAnswer { }

	[TLDef(0x75A3F765, "bind_auth_key_inner#75a3f765 nonce:long temp_auth_key_id:long perm_auth_key_id:long temp_session_id:long expires_at:int = BindAuthKeyInner")]
	public class BindAuthKeyInner : ITLObject
	{
		public long nonce;
		public long temp_auth_key_id;
		public long perm_auth_key_id;
		public long temp_session_id;
		public DateTime expires_at;
	}

	[TLDef(0xF35C6D01, "rpc_result#f35c6d01 req_msg_id:long result:Object = RpcResult")]
	public class RpcResult : ITLObject
	{
		public long req_msg_id;
		public object result;
	}

	[TLDef(0x2144CA19, "rpc_error#2144ca19 error_code:int error_message:string = RpcError")]
	public class RpcError : ITLObject
	{
		public int error_code;
		public string error_message;
	}

	public abstract class RpcDropAnswer : ITLObject { }
	[TLDef(0x5E2AD36E, "rpc_answer_unknown#5e2ad36e = RpcDropAnswer")]
	public class RpcAnswerUnknown : RpcDropAnswer { }
	[TLDef(0xCD78E586, "rpc_answer_dropped_running#cd78e586 = RpcDropAnswer")]
	public class RpcAnswerDroppedRunning : RpcDropAnswer { }
	[TLDef(0xA43AD8B7, "rpc_answer_dropped#a43ad8b7 msg_id:long seq_no:int bytes:int = RpcDropAnswer")]
	public class RpcAnswerDropped : RpcDropAnswer
	{
		public long msg_id;
		public int seq_no;
		public int bytes;
	}

	[TLDef(0x949D9DC, "future_salt#0949d9dc valid_since:int valid_until:int salt:long = FutureSalt")]
	public class FutureSalt : ITLObject
	{
		public DateTime valid_since;
		public DateTime valid_until;
		public long salt;
	}

	[TLDef(0xAE500895, "future_salts#ae500895 req_msg_id:long now:int salts:vector<future_salt> = FutureSalts")]
	public class FutureSalts : ITLObject
	{
		public long req_msg_id;
		public DateTime now;
		public FutureSalt[] salts;
	}

	[TLDef(0x347773C5, "pong#347773c5 msg_id:long ping_id:long = Pong")]
	public class Pong : ITLObject
	{
		public long msg_id;
		public long ping_id;
	}

	public abstract class DestroySessionRes : ITLObject { public long session_id; }
	[TLDef(0xE22045FC, "destroy_session_ok#e22045fc session_id:long = DestroySessionRes")]
	public class DestroySessionOk : DestroySessionRes { }
	[TLDef(0x62D350C9, "destroy_session_none#62d350c9 session_id:long = DestroySessionRes")]
	public class DestroySessionNone : DestroySessionRes { }

	public abstract class NewSession : ITLObject { }
	[TLDef(0x9EC20908, "new_session_created#9ec20908 first_msg_id:long unique_id:long server_salt:long = NewSession")]
	public class NewSessionCreated : NewSession
	{
		public long first_msg_id;
		public long unique_id;
		public long server_salt;
	}

	public abstract class MessageContainer : ITLObject { }
	[TLDef(0x73F1F8DC, "msg_container#73f1f8dc messages:vector<%Message> = MessageContainer")]
	public class MsgContainer : MessageContainer { public _Message[] messages; }

#pragma warning disable IDE1006 // Naming Styles
	//[TLDef("message msg_id:long seqno:int bytes:int body:Object = Message")]
	public class _Message
	{
		public long msg_id;
		public int seqno;
		public int bytes;
		public ITLObject body;
	}
#pragma warning restore IDE1006 // Naming Styles

	public abstract class MessageCopy : ITLObject { }
	[TLDef(0xE06046B2, "msg_copy#e06046b2 orig_message:Message = MessageCopy")]
	public class MsgCopy : MessageCopy { public _Message orig_message; }

	[TLDef(0x3072CFA1, "gzip_packed#3072cfa1 packed_data:bytes = Object")]
	public class GzipPacked : ITLObject { public byte[] packed_data; }

	[TLDef(0x62D6B459, "msgs_ack#62d6b459 msg_ids:Vector<long> = MsgsAck")]
	public class MsgsAck : ITLObject { public long[] msg_ids; }

	[TLDef(0xA7EFF811, "bad_msg_notification#a7eff811 bad_msg_id:long bad_msg_seqno:int error_code:int = BadMsgNotification")]
	public class BadMsgNotification : ITLObject
	{
		public long bad_msg_id;
		public int bad_msg_seqno;
		public int error_code;
	}
	[TLDef(0xEDAB447B, "bad_server_salt#edab447b bad_msg_id:long bad_msg_seqno:int error_code:int new_server_salt:long = BadMsgNotification")]
	public class BadServerSalt : BadMsgNotification { public long new_server_salt; }

	[TLDef(0x7D861A08, "msg_resend_req#7d861a08 msg_ids:Vector<long> = MsgResendReq")]
	public class MsgResendReq : ITLObject { public long[] msg_ids; }

	[TLDef(0xDA69FB52, "msgs_state_req#da69fb52 msg_ids:Vector<long> = MsgsStateReq")]
	public class MsgsStateReq : ITLObject { public long[] msg_ids; }

	[TLDef(0x4DEB57D, "msgs_state_info#04deb57d req_msg_id:long info:bytes = MsgsStateInfo")]
	public class MsgsStateInfo : ITLObject
	{
		public long req_msg_id;
		public byte[] info;
	}

	[TLDef(0x8CC0D131, "msgs_all_info#8cc0d131 msg_ids:Vector<long> info:bytes = MsgsAllInfo")]
	public class MsgsAllInfo : ITLObject
	{
		public long[] msg_ids;
		public byte[] info;
	}

	public abstract class MsgDetailedInfoBase : ITLObject { }
	[TLDef(0x276D3EC6, "msg_detailed_info#276d3ec6 msg_id:long answer_msg_id:long bytes:int status:int = MsgDetailedInfo")]
	public class MsgDetailedInfo : MsgDetailedInfoBase
	{
		public long msg_id;
		public long answer_msg_id;
		public int bytes;
		public int status;
	}
	[TLDef(0x809DB6DF, "msg_new_detailed_info#809db6df answer_msg_id:long bytes:int status:int = MsgDetailedInfo")]
	public class MsgNewDetailedInfo : MsgDetailedInfoBase
	{
		public long answer_msg_id;
		public int bytes;
		public int status;
	}

	[TLDef(0x7A19CB76, "rsa_public_key n:string e:string = RSAPublicKey")]
	public class RSAPublicKey : ITLObject
	{
		public byte[] n;
		public byte[] e;
	}

	public abstract class DestroyAuthKeyRes : ITLObject { }
	[TLDef(0xF660E1D4, "destroy_auth_key_ok#f660e1d4 = DestroyAuthKeyRes")]
	public class DestroyAuthKeyOk : DestroyAuthKeyRes { }
	[TLDef(0xA9F2259, "destroy_auth_key_none#0a9f2259 = DestroyAuthKeyRes")]
	public class DestroyAuthKeyNone : DestroyAuthKeyRes { }
	[TLDef(0xEA109B13, "destroy_auth_key_fail#ea109b13 = DestroyAuthKeyRes")]
	public class DestroyAuthKeyFail : DestroyAuthKeyRes { }

	// ---functions---

	[TLDef(0X60469778, "req_pq#60469778 nonce:int128 = ResPQ")]
	public class ReqPQ : ITLFunction<ResPQ> { public Int128 nonce; }
	[TLDef(0xBE7E8EF1, "req_pq_multi#be7e8ef1 nonce:int128 = ResPQ")]
	public class ReqPQmulti : ResPQ { }

	[TLDef(0xD712E4BE, "req_DH_params#d712e4be nonce:int128 server_nonce:int128 p:bytes q:bytes public_key_fingerprint:long encrypted_data:bytes = Server_DH_Params")]
	public class ReqDHParams : ITLFunction<ServerDHParams>
	{
		public Int128 nonce;
		public Int128 server_nonce;
		public byte[] p;
		public byte[] q;
		public long public_key_fingerprint;
		public byte[] encrypted_data;
	}

	[TLDef(0xF5045F1F, "set_client_DH_params#f5045f1f nonce:int128 server_nonce:int128 encrypted_data:bytes = Set_client_DH_params_answer")]
	public class SetClientDHParams : ITLFunction<SetClientDHParamsAnswer>
	{
		public Int128 nonce;
		public Int128 server_nonce;
		public byte[] encrypted_data;
	}

	[TLDef(0x58E4A740, "rpc_drop_answer#58e4a740 req_msg_id:long = RpcDropAnswer")]
	public class ReqRpcDropAnswer : ITLFunction<RpcDropAnswer> { public long req_msg_id; }

	[TLDef(0xB921BD04, "get_future_salts#b921bd04 num:int = FutureSalts")]
	public class GetFutureSalts : ITLFunction<FutureSalts> { public int num; }

	[TLDef(0x7ABE77EC, "ping#7abe77ec ping_id:long = Pong")]
	public class Ping : ITLFunction<Pong> { public long ping_id; }

	[TLDef(0xF3427B8C, "ping_delay_disconnect#f3427b8c ping_id:long disconnect_delay:int = Pong")]
	public class PingDelayDisconnect : ITLFunction<Pong>
	{
		public long ping_id;
		public int disconnect_delay; // seconds
	}

	[TLDef(0xE7512126, "destroy_session#e7512126 session_id:long = DestroySessionRes")]
	public class DestroySession : ITLFunction<DestroySessionRes> { public long session_id; }

	[TLDef(0x9299359F, "http_wait#9299359f max_delay:int wait_after:int max_wait:int = HttpWait")]
	public class HttpWait : ITLObject
	{
		public int max_delay;	// ms
		public int wait_after;	// ms
		public int max_wait;	// ms
	}

	[TLDef(0xD1435160, "destroy_auth_key#d1435160 = DestroyAuthKeyRes")]
	public class DestroyAuthKey : ITLFunction<DestroyAuthKeyRes> { }

}
